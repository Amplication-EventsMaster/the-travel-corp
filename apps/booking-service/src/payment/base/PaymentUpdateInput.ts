/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { InputType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsNumber,
  IsOptional,
  ValidateNested,
  IsDate,
  IsString,
} from "class-validator";
import { BookingWhereUniqueInput } from "../../booking/base/BookingWhereUniqueInput";
import { Type } from "class-transformer";

@InputType()
class PaymentUpdateInput {
  @ApiProperty({
    required: false,
    type: Number,
  })
  @IsNumber()
  @IsOptional()
  @Field(() => Number, {
    nullable: true,
  })
  amount?: number | null;

  @ApiProperty({
    required: false,
    type: () => BookingWhereUniqueInput,
  })
  @ValidateNested()
  @Type(() => BookingWhereUniqueInput)
  @IsOptional()
  @Field(() => BookingWhereUniqueInput, {
    nullable: true,
  })
  booking?: BookingWhereUniqueInput | null;

  @ApiProperty({
    required: false,
  })
  @IsDate()
  @Type(() => Date)
  @IsOptional()
  @Field(() => Date, {
    nullable: true,
  })
  date?: Date | null;

  @ApiProperty({
    required: false,
    type: String,
  })
  @IsString()
  @IsOptional()
  @Field(() => String, {
    nullable: true,
  })
  method?: string | null;
}

export { PaymentUpdateInput as PaymentUpdateInput };
