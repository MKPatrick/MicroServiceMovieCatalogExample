import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditmenueComponent } from './editmenue.component';

describe('EditmenueComponent', () => {
  let component: EditmenueComponent;
  let fixture: ComponentFixture<EditmenueComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditmenueComponent],
    });
    fixture = TestBed.createComponent(EditmenueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
