import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteproComponent } from './deletepro.component';

describe('DeleteproComponent', () => {
  let component: DeleteproComponent;
  let fixture: ComponentFixture<DeleteproComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteproComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteproComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
