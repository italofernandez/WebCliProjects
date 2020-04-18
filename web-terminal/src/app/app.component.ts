import { Component, OnInit } from '@angular/core';
import { ApiService } from './shared/services/api-service';
import { Command } from './shared/models/command.model';
import { CustomFormatters } from './shared/formatters/custom-formatters';
import { Machine } from './shared/models/machine.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  outputLines = [''];
  input: string = '';
  selectedMachine: Machine;
  machineList: Machine[] = [];
  isLoading: boolean = false;

  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.service.GetMachinesList().subscribe(
      r=>{
        console.log(r.data);
        this.machineList = r.data;
        this.selectedMachine = this.machineList[0];
      },
      error => {
        console.log('não funcionou');
      }
    );
  }

  executeCommand() {
    if (this.input.length > 0) {
      this.isLoading = true;

      let command = new Command();
      command.instruction = this.input;
      command.machineAddress = this.selectedMachine.localAddress;

      this.service.ExecuteCommand(command).subscribe(
        resp => {
          this.outputLines = CustomFormatters.removeLineBreakeCharaters(resp.data);
          this.isLoading = false;
        },
        error => {
          console.log(error);
          this.isLoading = false;
        },
        () => {
          this.isLoading = false;
        }
      );
    }
  }

  onMachineSelect(machine: Machine) {
    this.selectedMachine = machine;
  }
}
