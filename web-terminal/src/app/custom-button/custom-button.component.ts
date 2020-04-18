import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'custom-button',
  templateUrl: './custom-button.component.html',
  styleUrls: ['./custom-button.component.css']
})
export class CustomButtonComponent implements OnInit {

  @Input() buttonText: string = 'Define a Text';
  @Input() isLoading: boolean = false;

  @Output() onClick = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  buttonClick() {
    if(!this.isLoading)
      this.onClick.emit();
  }
}
