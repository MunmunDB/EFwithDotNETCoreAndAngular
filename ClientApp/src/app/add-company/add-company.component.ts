import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Company } from '../Model/company'
import { CompanyService } from '../Service/company.service'


@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html'
})

export class AddCompanyComponent implements OnInit {
  addCompanyForm: Company = new Company();
  @ViewChild("companyform")
  companyform!: NgForm;
  isSubmitted: boolean = false;
  angForm!: FormGroup;
  message = '';
  constructor(private router: Router, private service: CompanyService, private fb: FormBuilder) { this.createForm(); }

  ngOnInit(): void { }
  AddCompany(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.message = 'create record';
       this.service.AddCompany(this.addCompanyForm);
    }
  }
  createForm() {
    this.angForm = this.fb.group({
      name: ['', Validators.required]
    });
  }

}


