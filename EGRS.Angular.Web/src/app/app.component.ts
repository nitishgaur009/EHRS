import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthService } from './services/auth.service';
import { NgProgress, NgProgressRef, NgProgressState } from '@ngx-progressbar/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {
  progressRef: NgProgressRef;
  progressState: NgProgressState;

  constructor(private authService: AuthService,
    public ngProgress: NgProgress) {
  }

  ngOnInit() {
    this.progressRef = this.ngProgress.ref();
    this.progressRef.state
      .subscribe((state: NgProgressState) => {
        this.progressState = state;
      });
  }

  ngOnDestroy() {
    this.progressRef.destroy();
  }
}