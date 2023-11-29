import { Component, Inject, Input, OnInit, inject } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Stream } from 'src/app/models/stream';
import { StreamService } from 'src/app/services/stream.service';
import { environment } from 'src/environments/environment';
import { EditStreamComponent } from '../edit/edit-stream/edit-stream.component';

@Component({
  selector: 'app-Stream',
  templateUrl: './Stream.component.html',
  styleUrls: ['./Stream.component.css'],
})
export class StreamComponent implements OnInit {
  baseURL: string = environment.apiBaseServerURL;
  @Input() movieID!: number;
  modalService = inject(NgbModal);
  stream!: Stream;
  constructor(
    private streamService: StreamService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const idParam = this.route.snapshot.paramMap.get('id');
    this.movieID = idParam ? +idParam : 0;

    this.streamService.getStreamForMovie(this.movieID).subscribe((str) => {
      this.stream = str;
    },()=>
    {

    });
  }

  AddNewStream()
  {
const streamModalReference=this.modalService.open(EditStreamComponent);
streamModalReference.componentInstance.MovieID=this.movieID;
streamModalReference.result.then(res=>
{
this.stream=res;
})
  }
}
