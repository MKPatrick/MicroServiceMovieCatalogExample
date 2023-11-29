import { Injectable } from '@angular/core';
import { Stream } from '../models/stream';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class StreamService {

    
baseURL:string= environment.apiBaseServerURL +"/api/s/moviestreams";
constructor(private httpClient:HttpClient) { }


getStreamForMovie(id:number):Observable<Stream>
{
return this.httpClient.get<Stream>(`${this.baseURL}/GetMovieStreamByMovieID/${id}`);
}


addStream(stream:FormData):Observable<Stream>
{
    return this.httpClient.post<Stream>(`${this.baseURL}`,stream);
}


updateStream(stream:FormData):Observable<any>
{
    return this.httpClient.put(`${this.baseURL}`,stream);
}

deleteStream(streamID:number):Observable<any>
{
    return this.httpClient.delete(`${this.baseURL}/${streamID}`);
}

}
