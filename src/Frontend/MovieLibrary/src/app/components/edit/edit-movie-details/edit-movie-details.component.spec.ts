import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMovieDetailsComponent } from './edit-movie-details.component';

describe('EditMovieDetailsComponent', () => {
  let component: EditMovieDetailsComponent;
  let fixture: ComponentFixture<EditMovieDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EditMovieDetailsComponent],
    });
    fixture = TestBed.createComponent(EditMovieDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
