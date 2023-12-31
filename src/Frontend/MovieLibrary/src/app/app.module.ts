import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MoviecardComponent } from './components/moviecard/moviecard.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MovieService } from './services/movie.service';
import { StreamService } from './services/stream.service';
import { RatingService } from './services/rating.service';
import { MovielistComponent } from './components/movielist/movielist/movielist.component';
import { StreamComponent } from './components/Stream/Stream.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';

import { RatingComponent } from './components/rating/rating.component';
import { FormsModule } from '@angular/forms';
import { Addmovie } from './models/addmovie';
import { AddmovieComponent } from './components/addmovie/addmovie.component';
import { AddmoviestreamComponent } from './components/addmoviestream/addmoviestream.component';
import { MovietableComponent } from './components/movietable/movietable.component';
import { EditmenueComponent } from './components/edit/editmenue/editmenue.component';
import { EditStreamComponent } from './components/edit/edit-stream/edit-stream.component';
import { EditMovieDetailsComponent } from './components/edit/edit-movie-details/edit-movie-details.component';

@NgModule({
  declarations: [
    AppComponent,
    MoviecardComponent,
    MovielistComponent,
    StreamComponent,
    MoviedetailsComponent,
    RatingComponent,
    AddmoviestreamComponent,
    AddmovieComponent,
    MovietableComponent,
    EditmenueComponent,
    MovietableComponent,
    EditStreamComponent,
    EditMovieDetailsComponent,
    EditmenueComponent,
    EditStreamComponent,
    EditMovieDetailsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
  ],
  providers: [MovieService, StreamService, RatingService],
  bootstrap: [AppComponent],
})
export class AppModule {}
