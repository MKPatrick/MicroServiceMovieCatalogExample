import { Component, Input, OnInit, inject } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Addmovie } from 'src/app/models/addmovie';
import { ReleaseDate, Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';
import { AddmoviestreamComponent } from '../addmoviestream/addmoviestream.component';

@Component({
  selector: 'app-addmovie',
  templateUrl: './addmovie.component.html',
  styleUrls: ['./addmovie.component.css']
})
export class AddmovieComponent implements OnInit {

  addMovieModel:Addmovie;
  selectedReleaseDate!:string;
  imageFile!:File;
  errorMsg!:string;
  activeModal = inject(NgbActiveModal);
  modalService = inject(NgbModal);
  constructor(private movieService:MovieService) { 
    this.addMovieModel=new Addmovie();
      this.addMovieModel.releaseDate=new ReleaseDate();
  }

  ngOnInit() {
  }

  onFileSelected(event:any) {

    this.imageFile = event.target.files[0];
   
    }

  OnSubmit()
  {

    const date = new Date(this.selectedReleaseDate);

    this.addMovieModel.releaseDate.day=date.getDate();
    this.addMovieModel.releaseDate.month=date.getMonth()+1;
    this.addMovieModel.releaseDate.year=date.getFullYear();
 
    const formData = new FormData();

    if(this.imageFile!=null)
    {
      formData.append("MovieImage", this.imageFile); 
    }

    formData.append("Title", this.addMovieModel.title); 
    formData.append("Description", this.addMovieModel.description); 
    formData.append("ReleaseDate.Day", this.addMovieModel.releaseDate.day.toString()); 
    formData.append("ReleaseDate.Month", this.addMovieModel.releaseDate.month.toString()); 
    formData.append("ReleaseDate.Year", this.addMovieModel.releaseDate.year.toString()); 
this.movieService.addMovie(formData).subscribe(resp=>
{
this.movieService.moviesSubject.next(resp);
this.activeModal.close(resp);

}, error=>
{
   this.errorMsg="Something went wrong...";
});
  }
}
