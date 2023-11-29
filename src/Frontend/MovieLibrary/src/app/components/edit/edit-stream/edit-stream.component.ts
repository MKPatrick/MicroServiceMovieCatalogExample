import { Component, Input, inject, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StreamService } from 'src/app/services/stream.service';
import { Stream } from 'src/app/models/stream';

@Component({
  selector: 'app-edit-stream',
  templateUrl: './edit-stream.component.html',
  styleUrls: ['./edit-stream.component.css'],
})
export class EditStreamComponent implements OnInit {
  @Input() MovieID!: number;
  activeModal = inject(NgbActiveModal);
  modalService = inject(NgbModal);
  movieStreamFile!: File;
  editMovieStream!: Stream;

  constructor(private streamService: StreamService) {}

  ngOnInit(): void {
    this.streamService.getStreamForMovie(this.MovieID).subscribe(
      (result) => {
        this.editMovieStream = result;
      },
      (error) => {
        this.editMovieStream = new Stream();
        this.editMovieStream.movieID = this.MovieID;
      }
    );
  }

  OnSubmit() {
    const formData = new FormData();
    formData.append('FormMovieFile', this.movieStreamFile);
    formData.append('MovieID', this.editMovieStream.movieID.toString());

    if (this.editMovieStream.id != null) {
      formData.append('ID', this.editMovieStream.id.toString());
      this.streamService.updateStream(formData).subscribe(() => {
        this.activeModal.close();
      });
    } else {
      this.streamService.addStream(formData).subscribe(() => {
        this.activeModal.close();
      });
    }
  }

  onFileSelected(event: any) {
    this.movieStreamFile = event.target.files[0];
  }
}
