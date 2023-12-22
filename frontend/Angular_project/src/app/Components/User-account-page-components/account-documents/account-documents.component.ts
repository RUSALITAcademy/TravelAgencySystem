import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-account-documents',
  templateUrl: './account-documents.component.html',
  styleUrls: ['./account-documents.component.scss']
})
export class AccountDocumentsComponent implements OnInit {

  pasportForm: FormGroup;
  internationalPasportForm: FormGroup;

  constructor(private fb: FormBuilder) {
    this.pasportForm = this.fb.group({
      passport_series: ['',],
      passport_number: ['',],
      passport_name: ['',],
      passport_surname: ['',],
      passport_patronymic: ['',],
    });
    this.internationalPasportForm = this.fb.group({
      international_pasport_series: ['',],
      international_pasport_number: ['',],
      international_pasport_name: ['',],
      international_pasport_surname: ['',],
      international_pasport_patronymic: ['',],
    });
  }

  ngOnInit() {

  }
}
