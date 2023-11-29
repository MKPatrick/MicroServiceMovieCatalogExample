import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Movie } from '../models/movie';
import { environment } from 'src/environments/environment';
import { Form } from '@angular/forms';

@Injectable({ providedIn: 'root' })
@Injectable()
export class MovieService {
  moviesSubject = new Subject<Movie>();
  NewMovieAdded$ = this.moviesSubject.asObservable();
  baseURL: string = environment.apiBaseServerURL + '/api/m/movies';
  constructor(private httpClient: HttpClient) {}

  getMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(this.baseURL);
  }

  getMovieByID(id: number): Observable<Movie> {
    return this.httpClient.get<Movie>(`${this.baseURL}/${id}`);
  }

  updateMovie(movie: FormData): Observable<any> {
    return this.httpClient.put(`${this.baseURL}`, movie);
  }

  deleteMovie(id: number): Observable<any> {
    return this.httpClient.delete(`${this.baseURL}/${id}`);
  }

  addMovie(movieForm: FormData): Observable<Movie> {
    return this.httpClient.post<Movie>(`${this.baseURL}`, movieForm);
  }
}
