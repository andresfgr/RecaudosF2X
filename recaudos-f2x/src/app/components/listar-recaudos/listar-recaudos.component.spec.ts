import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarRecaudosComponent } from './listar-recaudos.component';

describe('ListarRecaudosComponent', () => {
  let component: ListarRecaudosComponent;
  let fixture: ComponentFixture<ListarRecaudosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarRecaudosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarRecaudosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
