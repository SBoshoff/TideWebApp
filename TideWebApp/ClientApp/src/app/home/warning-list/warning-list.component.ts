import { Component, Input, OnInit } from '@angular/core';
import { FloodWarning } from 'src/app/models/flood-warning.model';

const AlertLevel = {
  Severe: 1,
  High: 2,
  Mild: 3,
  None: 4
};

@Component({
  selector: 'app-warning-list',
  templateUrl: './warning-list.component.html',
  styleUrls: ['./warning-list.component.css']
})
export class WarningListComponent implements OnInit {

  AlertLevel = AlertLevel;

  @Input() tableData: FloodWarning[];
  selectedItem: FloodWarning = null;

  constructor() { }

  ngOnInit() {
  }

  selectItem(item: FloodWarning){
    console.log(item);
    this.selectedItem =  item;
  }

}
