import { Injectable, Inject } from '@angular/core';
import { Company } from '../Model/company'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs/internal/Observable';
import { CompanyResponse } from '../Model/CompanyResponse';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {

  constructor(private httpclient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  AddCompany(data: Company): Observable<CompanyResponse> {
    console.log(data);
    return this.httpclient.post<CompanyResponse>(this.baseUrl + 'Company/AddCompany', data);
  }
}
