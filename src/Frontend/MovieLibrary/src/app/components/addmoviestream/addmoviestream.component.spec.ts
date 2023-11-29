/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { AddmoviestreamComponent } from './addmoviestream.component';

describe('AddmoviestreamComponent', () => {
  let component: AddmoviestreamComponent;
  let fixture: ComponentFixture<AddmoviestreamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddmoviestreamComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddmoviestreamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
