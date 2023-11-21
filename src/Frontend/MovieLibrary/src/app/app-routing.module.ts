import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MovielistComponent } from './components/movielist/movielist/movielist.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';

const routes: Routes = [
  { path: '', component: MovielistComponent },
  { path: 'MovieDetails/:id', component: MoviedetailsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
