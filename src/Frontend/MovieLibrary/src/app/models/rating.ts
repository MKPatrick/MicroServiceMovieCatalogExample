export class Rating {
    id!: number;
    movieID!: number;
    movieRatedStar!: MovieStar;
    comment!: string;
    ratedTime!: Date;

}

enum MovieStar {
    VeryBad = 1,
    Bad = 2,
    OK = 3,
    Great = 4,
    Excellent = 5
}

