import { Component, OnInit, inject, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Stream } from 'src/app/models/stream';
import { StreamService } from 'src/app/services/stream.service';

@Component({
  selector: 'app-addmoviestream',
  templateUrl: './addmoviestream.component.html',
  styleUrls: ['./addmoviestream.component.css']
})
export class AddmoviestreamComponent implements OnInit {
  movieStream!:File;
  addMovieStream:Stream;
  activeModal = inject(NgbActiveModal);
  modalService = inject(NgbModal);
  @Input() MovieID!: number;
  constructor(private streamService:StreamService) {
    this.addMovieStream=new Stream();
   }

  ngOnInit() {
    this.addMovieStream.movieID=this.MovieID;
  
  }

  onFileSelected(event:any) {

    this.movieStream = event.target.files[0];
   
    }

    OnSubmit()
    {
      const formData = new FormData();
      formData.append("FormMovieFile", this.movieStream); 
      formData.append("MovieID", this.MovieID.toString()); 
      this.streamService.addStream(formData).subscribe(()=>
      {
        this.activeModal.close();
      });
    }

}
