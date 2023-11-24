import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rating } from '../models/rating';
import { environment } from 'src/environments/environment';

@Injectable()
export class RatingService {

    baseURL:string= environment.apiBaseServerURL +"/api/r/";
    constructor(private httpClient:HttpClient) { }
    
    

    getRatingsForMovie(id:number):Observable<Rating[]>
    {
    return this.httpClient.get<Rating[]>(`${this.baseURL}MovieRatings/Movie/${id}`);
    }
    
    
    addRating(movieID:number,rating:Rating):Observable<any>
    {
        return this.httpClient.post(`${this.baseURL}Ratings`,rating);
    }
}
