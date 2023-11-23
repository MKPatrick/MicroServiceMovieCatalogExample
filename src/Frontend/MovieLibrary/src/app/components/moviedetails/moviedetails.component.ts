import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';
import { RatingService } from 'src/app/services/rating.service';
import { StreamService } from 'src/app/services/stream.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
@Component({
  selector: 'app-moviedetails',
  templateUrl: './moviedetails.component.html',
  styleUrls: ['./moviedetails.component.css']
})
export class MoviedetailsComponent implements OnInit {


  movie!:Movie;

  @Input() movieID!: number;

  constructor(private movieService:MovieService, private ratingService:RatingService,private route:ActivatedRoute) { }

  ngOnInit() {

    const idParam = this.route.snapshot.paramMap.get('id');
    this.movieID = idParam ? +idParam : 0; 


    
this.movieService.getMovieByID(this.movieID).subscribe(movie=>
  {
this.movie=movie;
  });

  }

}
