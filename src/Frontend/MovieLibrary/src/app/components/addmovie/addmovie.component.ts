import { Component, Input, OnInit, inject } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Addmovie } from 'src/app/models/addmovie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-addmovie',
  templateUrl: './addmovie.component.html',
  styleUrls: ['./addmovie.component.css']
})
export class AddmovieComponent implements OnInit {

  addMovieModel:Addmovie;
  activeModal = inject(NgbActiveModal);
  constructor(private movieService:MovieService) { 
    this.addMovieModel=new Addmovie();
  }

  ngOnInit() {
  }

  OnSubmit()
  {

  }
}
