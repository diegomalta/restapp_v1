import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

const DOMAIN_URL = 'http://localhost:5000';
const BASE_URL = 'api/reports/Dashboard';
const GETDAILYREPORT = 'v1/daily-report';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private httpClient: HttpClient) { }

  public getDailyReport(): Observable<any> {
    const url = `${DOMAIN_URL}/${BASE_URL}/${GETDAILYREPORT}`;
    return this.httpClient.get(url);
  }

}
