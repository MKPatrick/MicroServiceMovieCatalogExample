import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Rating } from 'src/app/models/rating';
import { RatingService } from 'src/app/services/rating.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css'],
})
export class RatingComponent implements OnInit {
  @Input() movieID!: number;
  ratings!: Rating[];
  newRating: Rating;
  alreadySubmitted: boolean;

  constructor(
    private ratingService: RatingService,
    private route: ActivatedRoute
  ) {
    this.alreadySubmitted = false;
    this.newRating = new Rating();
    this.newRating.movieRatedStar = 1;
  }

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.movieID = idParam ? +idParam : 0;
    this.newRating.movieID = this.movieID;
    this.ratingService.getRatingsForMovie(this.movieID).subscribe(
      (ratings) => {
        this.ratings = ratings;
      },
      (error) => {}
    );
  }

  submitNewRating() {
    this.ratingService
      .addRating(this.movieID, this.newRating)
      .subscribe((result) => {
        if (this.ratings == null) this.ratings = [];
        this.ratings.push(this.newRating);
        this.alreadySubmitted = true;
      });
  }

  counter(i: number) {
    return new Array(+i);
  }
}
