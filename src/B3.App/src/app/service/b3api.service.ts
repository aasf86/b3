import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class B3apiService {

  private routeCalculateInvestment: string = '/api/CDB/calculate-investment';

  constructor(private httpClient: HttpClient) { }

  calculateInvestment(obg: any) {
    return this.httpClient.post<any>(environment.api + this.routeCalculateInvestment, obg);
  }
}
