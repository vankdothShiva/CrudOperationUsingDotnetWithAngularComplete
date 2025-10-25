import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { InventoryService } from '../../inventory-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-invertory',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './invertory.html',
  styleUrl: './invertory.css'
})
export class Invertory {
  invertoryData={
    ProductId:0,                                                 //https://www.youtube.com/watch?v=3NFIvArOfXs&t=142s->follow this tube channel
    ProductName:'',
    AvailableQuantity:0,
    RecordsPoints:0
  }
  UpdateDataInput:boolean=false;

  Data: any[] = [];

  constructor(private inventoryService:InventoryService) {
  }

  ngOnInit(){

this.GetData();
  }
  ngAfterInit(){
    this.GetData();
  }
// onsubmit():void{

//   this.inventoryService.PostData(this.invertoryData).subscribe(res=>{
//     console.log(res);
//     this.GetData();
//   });

//   alert("form submitted successfully" +JSON.stringify(this.invertoryData));
//    this.ngOnInit();
// }
GetData():void{

  this.inventoryService.GetData().subscribe(res=>{
  this.Data=res;
    console.log(res);
  });


}

DeleteData(id:number):void{

  this.inventoryService.DeleteData(id).subscribe(res=>{
    console.log(res);
 this.ngOnInit();
  });
}

// updateDatas(id:number,Data:any):void{
//   this.inventoryService.updateData(id,Data).subscribe(res=>{
//     console.log(res);
//  this.ngOnInit();
//   });
// }
Filled:[]=[];

UpdateData(item:any):void{
this.invertoryData.ProductId=item.productId;
this.invertoryData.ProductName=item.productName;
this.invertoryData.AvailableQuantity=item.availableQuantity;
this.invertoryData.RecordsPoints=item.recordsPoints;
this.Filled=item;
console.log(this.Filled);
this.UpdateDataInput=true;

}


onsubmit():void{
if(this.UpdateDataInput==true){
  this.inventoryService.updateData(this.invertoryData).subscribe(res=>{
    console.log(res);
    this.GetData();
  });

  alert("form Update successfully" +JSON.stringify(this.invertoryData));
   this.ngOnInit();
}
else{
  this.inventoryService.PostData(this.invertoryData).subscribe(res=>{
    console.log(res);
    this.GetData();
  });

  alert("form submitted successfully" +JSON.stringify(this.invertoryData));
   this.ngOnInit();
}

}








}