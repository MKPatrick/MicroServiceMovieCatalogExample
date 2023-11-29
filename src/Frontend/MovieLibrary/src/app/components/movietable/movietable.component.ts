import { Component, OnInit } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-movietable',
  templateUrl: './movietable.component.html',
  styleUrls: ['./movietable.component.css']
})
export class MovietableComponent  implements OnInit {
 
  movies:Movie[];
  constructor(private movieService:MovieService) {this.movies=[] }

  ngOnInit() {
   this.movieService.getMovies().subscribe(res=>
   {
this.movies=res;
   });
  }


  DeleteMovie(movie:Movie)
  {
    if(confirm("Are you sure to delete "+movie.title)) {
this.movieService.deleteMovie(movie.id).subscribe(()=>
{

});
this.movies = this.movies.filter(obj => movie !== obj);
    }
    
  }


}
