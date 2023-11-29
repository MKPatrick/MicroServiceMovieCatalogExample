import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovielistComponent } from './components/movielist/movielist/movielist.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';
import { MovietableComponent } from './components/movietable/movietable.component';

const routes: Routes = [
  { path: '', component: MovielistComponent },
  { path: 'MovieTable', component: MovietableComponent },
  { path: 'MovieDetails/:id', component: MoviedetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
