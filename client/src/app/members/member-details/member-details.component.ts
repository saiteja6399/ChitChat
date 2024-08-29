import { Component, inject, OnInit } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../../_models/Member';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { Gallery, GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';

@Component({
  selector: 'app-member-details',
  standalone: true,
  imports: [TabsModule, GalleryModule],
  templateUrl: './member-details.component.html',
  styleUrl: './member-details.component.css',
})
export class MemberDetailsComponent implements OnInit {
  private memberService = inject(MembersService);
  route = inject(ActivatedRoute);
  member?: Member;
  images: GalleryItem[] = [];

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    var username = this.route.snapshot.paramMap.get('username');
    if (!username) return;

    this.memberService.getMemberByUsername(username).subscribe({
      next: (member) => {
        this.member = member;
        this.member.photos.map((p) => {
          this.images.push(
            new ImageItem({
              src: p.url,
              thumb: p.url,
            })
          );
        });
      },
    });
  }
}
