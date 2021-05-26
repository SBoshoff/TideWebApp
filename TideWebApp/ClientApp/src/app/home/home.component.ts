import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FloodWarning } from '../models/flood-warning.model';
import { HttpServiceService } from '../services/http-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  query = {region: '', pageSize: 0, pageNum: 0};
  data: FloodWarning[] = [];

  queryForm = new FormGroup({
    name: new FormControl(this.query.region, [
      Validators.required
    ]),
    pageSize: new FormControl(this.query.pageSize, [
      Validators.min(1),
      Validators.required
    ]),
    pageNum: new FormControl(this.query.pageNum, [
      Validators.min(1),
      Validators.required
    ])
  })

  get name() {return this.queryForm.get('name')}
  get pageSize() {return this.queryForm.get('pageSize')}
  get pageNum() {return this.queryForm.get('pageNum')}

  constructor(private httpService: HttpServiceService){

  }

  ngOnInit(){
    this.query.region = '';
    this.query.pageNum = 1;
    this.query.pageSize = 5;
  }

  submit(){
    this.httpService.getFloodWarnings(this.query).subscribe(result => {
      this.data = result;
    });
  }
}
