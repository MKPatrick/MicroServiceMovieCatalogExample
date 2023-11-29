import { Component, inject, Input } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Movie } from 'src/app/models/movie';
import { EditStreamComponent } from '../edit-stream/edit-stream.component';
import { EditMovieDetailsComponent } from '../edit-movie-details/edit-movie-details.component';

@Component({
  selector: 'app-editmenue',
  templateUrl: './editmenue.component.html',
  styleUrls: ['./editmenue.component.css']
})
export class EditmenueComponent {
   modalService = inject(NgbModal);
   activeModal = inject(NgbActiveModal);
  @Input() MovieID!: number;


  EditStream()
  {
const openedModal=this.modalService.open(EditStreamComponent);
openedModal.componentInstance.MovieID=this.MovieID;
  }

  EditMovieDetails()
  {
  const openedModal=  this.modalService.open(EditMovieDetailsComponent);
  openedModal.componentInstance.MovieID=this.MovieID;  
  openedModal.result.then(result=>
  {
    
if(result!=null)
{
  this.activeModal.close(result);
}

  }, ()=>
  {
    this.activeModal.close();
  });
}
}
