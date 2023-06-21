import { Injectable , Inject } from '@angular/core';
import { Company } from '../Model/company'
import {HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root',
})
export class CompanyService {

  constructor(private httpclient: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  AddCompany(data: Company): any {
    console.log(data);
    this.httpclient.post(this.baseUrl + 'weatherforecast/AddCompany', data).subscribe(result => {
      console.log(result);
      return result;
    }, error => console.error(error));
  }
}
