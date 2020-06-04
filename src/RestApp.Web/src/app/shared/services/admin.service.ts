import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

const DOMAIN_URL = 'http://localhost:41219';
const BASE_URL = 'api/admin/products';
const GETPRODUCTS = 'v1/GetProducts';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) { }

  getProducts(): Observable<any[]> {
    const url = `${DOMAIN_URL}/${BASE_URL}/${GETPRODUCTS}`;

    return this.httpClient.get<any[]>(url).pipe(
      tap(data => console.log('Product: ' + JSON.stringify(data)))
    );
  }
}
