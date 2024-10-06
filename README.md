We have pursued a State-based Migration strategy. Essentially, the entire state of our desired database is defined and Therefore we can take an empty database and bring it to the desired state. This is where we ended, anyway. Our Migration Process was actually the Change-based strategy initially, where the changes in each branch only reflected the changes needed to reach the next desired state of the database because we knew the previous state, with the script itself not being able to reach said state from an empty database. Anyhow, we've gone back to change it to how we "think" that we "should" have done it from the start? With each migration having its own script file following the state-based method. They are also prefixed with their place in the sequence


As for rollbacks, because each migration is rather simple, the process to roll them back is as well, with not a wohle lot to be said about it(?). As with  the migrations, they are also prefixed with their sequence number.
- 3_RollbackAddRatings
Simply deletes* the new ProductRatings table after also dropping the foreign key restraint. Dropping the constraint first should not strictly speaking be necessary here, given that ProductRatings is the table reliant on Products and not the other way around, i just like explicity deleting it (am used to working in a language where garbage does not get cleaned up by itself so yeah)
- 2_RollbackAddCategories
Here we do have to delete the restraint first, as Products is reliant on Categories, and when we created our constraints we also set up cascade on delete just to make sure deletion would be reversible. Afterwards we just drop the extra column of Products, whereafter we are certain we can drop Categories.
- 1_RollbackInitialSchema
Drops the only remaining table, Products, leaving us with an empty database.

The way it works in EntityFramework is that each Migration has its own Up() and Down() methods, which essentially do the same thing as we did manually self-explanatorily from their names. You just call the desired method on the desired migration in order to reach your desired state.

*We are aware that it is better practice to do "soft deletes" on our tables instead, which we could for example do by renaming them and thereby not lose any data. We just haven't done that
