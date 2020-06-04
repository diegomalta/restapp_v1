import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError, Observable, BehaviorSubject } from 'rxjs';

const DOMAIN_URL = 'http://localhost:41219';
const BASE_URL = 'api/security/Auth';
const GETTOKEN = 'v1/GenerateToken';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  TOKEN_KEY = 'token';
  TOKEN_EXPIRATION = 'tokenExpiration';

  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  isLoggenInAction$ = this.isLoggedInSubject.asObservable();

  constructor(private httpClient: HttpClient) { }

  public login(credentials): Observable<boolean> {
    const url = `${DOMAIN_URL}/${BASE_URL}/${GETTOKEN}`;

    return this.httpClient.post(url, JSON.stringify(credentials),
      { headers: this.SetHeaders(), withCredentials: false }
    ).pipe(
      map((response: any) => {
        if (response && response.token) {
          localStorage.setItem(this.TOKEN_KEY, response.token);
          localStorage.setItem(this.TOKEN_EXPIRATION, response.expiration);
          return true;
        }
        return false;
      }, catchError(this.handleError))
    );
  }

  public updateIsAuthenticated(): void {
    this.isLoggedInSubject.next(this.isAuthenticated());
  }

  public isAuthenticated(): boolean {
    return localStorage.getItem(this.TOKEN_KEY) != null &&
      localStorage.getItem(this.TOKEN_EXPIRATION) != null &&
      localStorage.getItem(this.TOKEN_KEY).length > 0 &&
      new Date(localStorage.getItem(this.TOKEN_EXPIRATION)) > new Date();
  }

  private SetHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
    });
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
