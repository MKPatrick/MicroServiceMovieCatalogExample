import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovietableComponent } from './movietable.component';

describe('MovietableComponent', () => {
  let component: MovietableComponent;
  let fixture: ComponentFixture<MovietableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MovietableComponent]
    });
    fixture = TestBed.createComponent(MovietableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
