import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Stream } from 'src/app/models/stream';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-Stream',
  templateUrl: './Stream.component.html',
  styleUrls: ['./Stream.component.css']
})
export class StreamComponent implements OnInit {

  @Input() movieID!: number;
  stream!:Stream ;
  constructor(private streamService:StreamService, private route:ActivatedRoute) { }

  ngOnInit() {

    this.route.paramMap.subscribe((params:ParamMap) => {
      this.movieID = +!params.get('id');
      this.streamService.getStreamForMovie(this.movieID).subscribe(stream=>
        {
      this.stream=stream;
        });
    });


  }

}
