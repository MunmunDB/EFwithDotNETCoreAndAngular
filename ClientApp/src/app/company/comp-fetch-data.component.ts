import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-comp-fetch-data',
  templateUrl: './comp-fetch-data.component.html'
})
export class CompFetchDataComponent {
  public compfetchdata: Company[] = [];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string ) {
    console.log(baseUrl);
    http.get<Company[]>(baseUrl + 'weatherforecast/getcompany').subscribe(result => {
      console.log(result);
      this.compfetchdata = result;
    }, error => console.error(error));
  }
}

interface Company {
  code: string;
  companyName: string;
  createdDate: Date;
  sharePrice: number;
  
}
