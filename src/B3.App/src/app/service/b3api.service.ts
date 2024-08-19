import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class B3apiService {

  constructor(private httpClient: HttpClient) {
    console.log('env', environment)
   }
}
