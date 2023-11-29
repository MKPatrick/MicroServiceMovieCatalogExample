import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-moviecard',
  templateUrl: './moviecard.component.html',
  styleUrls: ['./moviecard.component.css'],
})
export class MoviecardComponent implements OnInit {
  baseURL: string = environment.apiBaseServerURL;
  @Input() movie!: Movie;
  constructor() {}

  ngOnInit() {
    console.log(this.movie);
  }
}
