import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DiskCardListComponent } from './disk-card-list.component';

describe('DiskCardListComponent', () => {
  let component: DiskCardListComponent;
  let fixture: ComponentFixture<DiskCardListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DiskCardListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DiskCardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
