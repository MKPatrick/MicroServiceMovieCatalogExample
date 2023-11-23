import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Stream } from 'src/app/models/stream';
import { StreamService } from 'src/app/services/stream.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-Stream',
  templateUrl: './Stream.component.html',
  styleUrls: ['./Stream.component.css']
})
export class StreamComponent implements OnInit {
  baseURL:string= environment.apiBaseServerURL;
  @Input() movieID!: number;
  stream!:Stream ;
  constructor(private streamService:StreamService, private route:ActivatedRoute) { }

  ngOnInit() {

    const idParam = this.route.snapshot.paramMap.get('id');
    this.movieID = idParam ? +idParam : 0; 


    
this.streamService.getStreamForMovie(this.movieID).subscribe(str=>
  {
this.stream=str;
  });


  }

}
