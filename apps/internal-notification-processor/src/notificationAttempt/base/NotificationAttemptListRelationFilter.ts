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
import { NotificationAttemptWhereInput } from "./NotificationAttemptWhereInput";
import { ValidateNested, IsOptional } from "class-validator";
import { Type } from "class-transformer";

@InputType()
class NotificationAttemptListRelationFilter {
  @ApiProperty({
    required: false,
    type: () => NotificationAttemptWhereInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptWhereInput)
  @IsOptional()
  @Field(() => NotificationAttemptWhereInput, {
    nullable: true,
  })
  every?: NotificationAttemptWhereInput;

  @ApiProperty({
    required: false,
    type: () => NotificationAttemptWhereInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptWhereInput)
  @IsOptional()
  @Field(() => NotificationAttemptWhereInput, {
    nullable: true,
  })
  some?: NotificationAttemptWhereInput;

  @ApiProperty({
    required: false,
    type: () => NotificationAttemptWhereInput,
  })
  @ValidateNested()
  @Type(() => NotificationAttemptWhereInput)
  @IsOptional()
  @Field(() => NotificationAttemptWhereInput, {
    nullable: true,
  })
  none?: NotificationAttemptWhereInput;
}
export { NotificationAttemptListRelationFilter as NotificationAttemptListRelationFilter };
