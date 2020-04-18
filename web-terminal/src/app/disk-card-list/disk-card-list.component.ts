import { Component, OnInit, Input } from '@angular/core';
import { HardDriveInfos } from '../shared/models/value-objects/hard-drive-infos.models';

@Component({
  selector: 'disk-card-list',
  templateUrl: './disk-card-list.component.html',
  styleUrls: ['./disk-card-list.component.css']
})
export class DiskCardListComponent implements OnInit {

  @Input() collection: HardDriveInfos[];

  constructor() { }

  ngOnInit(): void {
  }

  getPercentage(total: string, freeSpace: string) : string {
    let _total: number = parseInt(total.replace(' GB', ''));
    let _freeSpace: number = parseInt(freeSpace.replace(' GB', ''));


    return Math.round(((_total - _freeSpace) * 100) / _total).toString();
  }

  getPercentageClass(total: string, freeSpace: string) : string {
    let _total: number = parseInt(total.replace(' GB', ''));
    let _freeSpace: number = parseInt(freeSpace.replace(' GB', ''));
    
    return "p" + Math.round(((_total - _freeSpace) * 100) / _total).toString();
  }
}
