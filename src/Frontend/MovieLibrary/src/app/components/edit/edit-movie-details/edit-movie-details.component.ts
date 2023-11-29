import { Component, Input, OnInit, Inject, inject } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from 'src/app/models/movie';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-edit-movie-details',
  templateUrl: './edit-movie-details.component.html',
  styleUrls: ['./edit-movie-details.component.css'],
})
export class EditMovieDetailsComponent implements OnInit {
  @Input() MovieID!: number;
  activeModal = inject(NgbActiveModal);
  modalService = inject(NgbModal);
  editMovie: Movie;
  imageFile!: File;
  selectedReleaseDate!: string;
  constructor(private movieservice: MovieService) {
    this.editMovie = new Movie();
  }
  ngOnInit(): void {
    this.editMovie.id = this.MovieID;
    this.movieservice.getMovieByID(this.MovieID).subscribe((res) => {
      this.editMovie = res;
      this.selectedReleaseDate = `${
        this.editMovie.releaseDate.year
      }-${this.leadingZero(
        this.editMovie.releaseDate.month,
        2
      )}-${this.leadingZero(this.editMovie.releaseDate.day, 2)}`;
      console.log(this.selectedReleaseDate);
    });
  }

  onFileSelected(event: any) {
    this.imageFile = event.target.files[0];
  }
  OnSubmit() {
    const date = new Date(this.selectedReleaseDate);
    this.editMovie.releaseDate.day = date.getDate();
    this.editMovie.releaseDate.month = date.getMonth() + 1;
    this.editMovie.releaseDate.year = date.getFullYear();
    const formData = new FormData();

    if (this.imageFile != null) {
      formData.append('MovieImage', this.imageFile);
    }
    formData.append('ID', this.editMovie.id.toString());
    formData.append('Title', this.editMovie.title);
    formData.append('Description', this.editMovie.description);
    formData.append(
      'ReleaseDate.Day',
      this.editMovie.releaseDate.day.toString()
    );
    formData.append(
      'ReleaseDate.Month',
      this.editMovie.releaseDate.month.toString()
    );
    formData.append(
      'ReleaseDate.Year',
      this.editMovie.releaseDate.year.toString()
    );
    this.movieservice.updateMovie(formData).subscribe(() => {
      this.activeModal.close(this.editMovie);
    });
  }

  leadingZero(num: number, size: number): string {
    let numConv = num.toString();
    while (numConv.length < size) numConv = '0' + num;
    return numConv;
  }
}
