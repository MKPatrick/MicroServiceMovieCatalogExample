import { Component, inject } from '@angular/core';
import { ModalDismissReasons, NgbDatepickerModule, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddmovieComponent } from './components/addmovie/addmovie.component';
import { AddmoviestreamComponent } from './components/addmoviestream/addmoviestream.component';
import { Movie } from './models/movie';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MovieLibrary';
  private modalService = inject(NgbModal);

  AddMovie():void
  {

    const modalRef = this.modalService.open(AddmovieComponent);
    modalRef.result.then(resp=>
    {
      const modal=this.modalService.open(AddmoviestreamComponent);
      modal.componentInstance.MovieID=resp.id;
      modal.result.then(()=>
      {
  //this is dirty..
  location.reload();
      },()=>
      {
        
      });
    
    });

  }
}
