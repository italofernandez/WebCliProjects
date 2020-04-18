import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { MachineCard } from '../shared/models/machine-card.model';
import { Machine } from '../shared/models/machine.model';

@Component({
  selector: 'card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {
  
  @Input() collection: Machine[];

  @Input() selectedMachine: Machine;

  @Output() onSelect = new EventEmitter<Machine>();

  constructor() { }

  ngOnInit(): void {
  }

  selectMachine(machine: Machine) {
    if(machine.id != this.selectedMachine.id)
      this.onSelect.emit(machine);
  }

  verifySelection(id: number) {
    return (id == this.selectedMachine.id);
  }
}
