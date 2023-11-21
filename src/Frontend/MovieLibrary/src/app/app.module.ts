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

@NgModule({
  declarations: [	
    AppComponent,
      MoviecardComponent, MovielistComponent
   ],
  imports: [
    BrowserModule,HttpClientModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [ MovieService, StreamService, RatingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
