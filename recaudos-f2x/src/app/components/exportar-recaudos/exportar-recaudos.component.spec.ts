import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExportarRecaudosComponent } from './exportar-recaudos.component';

describe('ExportarRecaudosComponent', () => {
  let component: ExportarRecaudosComponent;
  let fixture: ComponentFixture<ExportarRecaudosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExportarRecaudosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExportarRecaudosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
