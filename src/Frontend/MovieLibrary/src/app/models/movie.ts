export class Movie {
  id!: number;
  title!: string;
  description!: string;
  movieImage!: string;
  averageRating!: string;
  releaseDate!: ReleaseDate;
}

export class ReleaseDate {
  day!: number;
  month!: number;
  year!: number;
}
