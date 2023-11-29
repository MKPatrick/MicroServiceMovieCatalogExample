import { Component, OnInit, inject } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { Movie } from 'src/app/models/movie';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditmenueComponent } from '../edit/editmenue/editmenue.component';

@Component({
  selector: 'app-movietable',
  templateUrl: './movietable.component.html',
  styleUrls: ['./movietable.component.css']
})
export class MovietableComponent  implements OnInit {
 
  movies:Movie[];
  private modalService = inject(NgbModal);
  constructor(private movieService:MovieService) {this.movies=[] }

  ngOnInit() {
   this.movieService.getMovies().subscribe(res=>
   {
this.movies=res;
   });
  }


EditMovie(movie:Movie)
{
 const modalRef= this.modalService.open(EditmenueComponent);
modalRef.componentInstance.MovieID=movie.id;
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
