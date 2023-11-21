import { Component, Input, OnInit } from '@angular/core';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-moviecard',
  templateUrl: './moviecard.component.html',
  styleUrls: ['./moviecard.component.css']
})
export class MoviecardComponent implements OnInit {

  @Input() movie!: Movie;
  constructor() { }

  ngOnInit() {
  }

}
