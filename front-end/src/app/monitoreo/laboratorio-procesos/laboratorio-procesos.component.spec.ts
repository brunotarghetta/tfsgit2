import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LaboratorioProcesosComponent } from './laboratorio-procesos.component';

describe('LaboratorioProcesosComponent', () => {
  let component: LaboratorioProcesosComponent;
  let fixture: ComponentFixture<LaboratorioProcesosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LaboratorioProcesosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LaboratorioProcesosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
