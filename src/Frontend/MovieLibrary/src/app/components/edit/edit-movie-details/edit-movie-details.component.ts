import { Component, Input, OnInit, Inject, inject } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from 'src/app/models/movie';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-edit-movie-details',
  templateUrl: './edit-movie-details.component.html',
  styleUrls: ['./edit-movie-details.component.css']
})
export class EditMovieDetailsComponent implements OnInit {
  @Input() MovieID!: number;
  activeModal = inject(NgbActiveModal);
  modalService = inject(NgbModal);
  editMovie:Movie;
  imageFile!:File;
  selectedReleaseDate!:string;
 constructor (private movieservice:MovieService){
   this.editMovie=new Movie();
 }
  ngOnInit(): void {
   this.editMovie.id=this.MovieID;
   this.movieservice.getMovieByID(this.MovieID).subscribe(res=>
   {
this.editMovie=res;
this.selectedReleaseDate=`${this.editMovie.releaseDate.day}.${this.editMovie.releaseDate.month}.${this.editMovie.releaseDate.year}`;
this.selectedReleaseDate="2023-01-01";   
});
  }


  onFileSelected(event:any) {

    this.imageFile = event.target.files[0];
   
    }
  OnSubmit()
  {

  }

}
