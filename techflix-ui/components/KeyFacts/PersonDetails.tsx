import React, {FunctionComponent} from "react";
import {PersonModel} from "../../api/peopleApiClient";
import {Fact, FactList} from "./Fact";
import styles from "./PersonDetails.module.scss";
import moment from "moment";

interface PersonDetailsProps {
    person: PersonModel
}

export const PersonDetails: FunctionComponent<PersonDetailsProps> = ({person}) => {
    const age = moment().diff(person.dateOfBirth, 'years');
    var ageOrDateOfDeath;

    if (person.dateOfDeath == null) {
        ageOrDateOfDeath = <Fact name="Age" value={age}/>;
    } 
    else {
        ageOrDateOfDeath = <Fact name="Date of Death" value={person.dateOfDeath}/>;
    }


    return (
        <section className={styles.section}>
            <div className={styles.imageContainer}>
                <img className={styles.image} src={person.imageUrl} alt="Profile Image"/>
            </div>
            <div className={styles.detailsContainer}>
                <h2 className={styles.title}>Personal Details</h2>
                <Fact name="Date of Birth" value={person.dateOfBirth}/>
                {ageOrDateOfDeath}
                <Fact name="Place of Birth" value={person.placeOfBirth}/>
                <Fact name="Main career" value={person.knownFor}/>
                <FactList name="Also known as" values={person.alsoKnownAs}/>
            </div>
        </section>
    );
};


